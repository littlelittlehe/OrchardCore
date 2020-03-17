using System;
using System.Threading.Tasks;
using OrchardCore.Data.Documents;

namespace OrchardCore.Documents
{
    /// <summary>
    /// A generic service to keep in sync any <see cref="BaseDocument"/> between a document store and a shared cache.
    /// </summary>
    public interface IDocumentManager<TDocument> where TDocument : BaseDocument, new()
    {
        /// <summary>
        /// Loads a single document from the store or create a new one by using <see cref="ICacheableDocumentStore.GetMutableAsync"/>.
        /// </summary>
        Task<TDocument> GetMutableAsync(Func<TDocument> factory = null);

        /// <summary>
        /// Gets a single document from the cache or create a new one by using <see cref="ICacheableDocumentStore.GetImmutableAsync"/>.
        /// </summary>
        Task<TDocument> GetImmutableAsync(Func<TDocument> factory = null);

        /// <summary>
        /// Updates the store with the provided document and then updates the cache.
        /// </summary>
        Task UpdateAsync(TDocument document);
    }
}