using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementsService.API.Models
{
    public class ResultMessageModel
    {
        public int? AddId { get; set; }
        public int ResultCode { get; set; }
        public string Message { get; set; }
    }
}
