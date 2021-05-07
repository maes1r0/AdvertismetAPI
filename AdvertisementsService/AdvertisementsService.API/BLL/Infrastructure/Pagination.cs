using System;

namespace AdvertisementsService.API.BLL.Infrastructure
{
    public class Pagination
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; } = 10;
        public Pagination(int count, int pageNumber)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        }
        public bool IsValid
        {
            get
            {
                if (PageNumber >=1 && PageNumber <= TotalPages && PageSize != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
