using LabDatabasesBlazor.Components.Pages;
using LabDatabasesBlazor.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LabDatabasesBlazor.Service
{
    // Create a service for books connected to the MongoDB client.
    public class BookService
    {
        private readonly IMongoCollection<Book> _Books;

        public BookService(IOptions<DatabaseSettings> databaseSettings)
        {
            var settings = databaseSettings.Value;
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
            _Books = mongoDatabase.GetCollection<Book>(settings.BooksCollectionName);
        }

        // CREATE - Add a new book to MongoDB
        public async Task AddBookAsync(Book book)
        {
            await _Books.InsertOneAsync(book);
        }

        // READ - Get all books in the collection
        public async Task<List<Book>> GetBooksAsync()
        {
            var filter = Builders<Book>.Filter.Empty;
            return await _Books.Find(filter).ToListAsync();
        }

        // DELETE - Remove a book by its ID
        public async Task DeleteBookAsync(string id)
        {
            await _Books.DeleteOneAsync(book => book.Id == id);
        }

        // UPDATE - Replace an entire book document
        public async Task ReplaceBookAsync(string id, Book updatedBook)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            await _Books.ReplaceOneAsync(filter, updatedBook);
        }

        // ADD REVIEW - Add a review to a specific book
        public async Task AddReviewAsync(string bookId, Review newReview)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, bookId);
            var update = Builders<Book>.Update.Push(book => book.Reviews, newReview);
            await _Books.UpdateOneAsync(filter, update);
        }

        // UPDATE REVIEW - Update a specific review for a book
        public async Task UpdateReviewAsync(string bookId, Review updatedReview)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, bookId) &
            Builders<Book>.Filter.ElemMatch(book => book.Reviews, review => review.ReviewerName == updatedReview.ReviewerName);
            var update = Builders<Book>.Update
                .Set("Reviews.$.ReviewerName", updatedReview.ReviewerName)
                .Set("Reviews.$.Rating", updatedReview.Rating)
                .Set("Reviews.$.Comment", updatedReview.Comment);
            await _Books.UpdateOneAsync(filter, update);
        }

        // DELETE REVIEW - Delete a specific review from a book
        public async Task DeleteReviewAsync(string bookId, string reviewerName)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, bookId);
            var update = Builders<Book>.Update.PullFilter(book => book.Reviews, review => review.ReviewerName == reviewerName);
            await _Books.UpdateOneAsync(filter, update);
        }
    }
}
