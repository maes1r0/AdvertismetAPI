using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementsService.API.BLL.Interfaces;
using AdvertisementsService.API.BLL.DTO;
using AdvertisementsService.API.BLL.Services;
using AdvertisementsService.API.Models;

namespace AdvertisementsService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("[action]")]
    public class ApiController : Controller
    {
        private readonly IAdService adService;
        public ApiController(IAdService adService)
        {
            this.adService = adService;
        }
        [HttpGet]
        [Route("[action]")]
        public JsonResult Home()
        {
            return Json(new { message = "Write your reqests by url" });
        }
        [HttpGet]
        [Route("[action]")]
        public JsonResult Get(int id, bool fields = false)
        {
            object temp = adService.GetAd(id, fields);
            if (temp != null)
            {
                if (fields == true)
                {
                    return Json(temp as OptionalPresAdDTO);
                }
                else
                {
                    return Json(temp as SmallPresAdDTO);
                }
            }
            else
            {
                return Json(new ResultMessageModel() { ResultCode = 400, Message = "Invalid id" });
            }
        }
        [HttpGet]
        [Route("[action]")]
        public JsonResult GetAll(int page = 1, string field = "", bool increase = false)
        {
            var items = adService.GetAllAds(page, field, increase);
            if (items != null)
            {
                return Json(items);
            }
            else
            {
                return Json(new ResultMessageModel() { ResultCode = 404, Message="Page or items not found" });
            }
        }
        [HttpPost]
        [Route("[action]")]
        public JsonResult Create([FromBody]DefaultAdDTO item)
        {
                adService.CreateAd(item);
                return Json(new ResultMessageModel() { AddId = adService.GetAllAds().Last().Id, ResultCode = 201, Message = "Success" });
        }
    }
}
