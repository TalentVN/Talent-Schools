using System.Collections.Generic;

namespace TSM.Models
{
    public class PagingModel<TModel> where TModel : class
    {
        public PagingModel(int currentPage, int totalPages, IEnumerable<TModel> data)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            Data = data;
        }

        public int CurrentPage { get; }

        public int TotalPages { get; }

        public IEnumerable<TModel> Data { get; }
    }
}
