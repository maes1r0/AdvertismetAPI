# AdvertismetAPI
Service for storing and submitting ads. Ads are stored in a database. The service provides an API that runs on top of HTTP in JSON format.

Url: https://advertisementsserviceapi.azurewebsites.net/Api/Home


Api have 3 methods:
1. Create
2. Get
3. GetAll

**Create:**

*Request Url:*
https://advertisementsserviceapi.azurewebsites.net/Api/Create 

*Body request:*

```
{
    "AdTitle": "<title>",
    "Description": "<description>",
    "ImageUriList": 
        [
            {
                "Uri": "<first_url>"
            },
            {
                "Uri": "<second_url>"
            },
            {
                "Uri": "<third_url>"
            }
        ],
    "Price": <price>
}
```
*Success response:*
```
{
    "addId": 2,
    "resultCode": 201,
    "message": "Success"
}
```
* 2 - id of created object
* 201 - http code
* Success- message explaining http code

 **Rules for filling out the request fields**
* Max url count: 3
* Max title length: 200 symbols
* Max description length: 1000 symbols
 
 **Get:**
 
 *Request Url:*
https://advertisementsserviceapi.azurewebsites.net/Api/Get

*Parameters*
* int id - id of object you wanna get
* bool fields - optional parameter, used if you wanna get more detailed object

*Example request*

`https://advertisementsserviceapi.azurewebsites.net/Api/Get?id=1`

`https://advertisementsserviceapi.azurewebsites.net/Api/Get?id=1&fields=true`

*Success response:*
```
{
    "adTitle": "FirstAd",
    "imageUri": {
        "uri": "https://upload.wikimedia.org/wikipedia/commons/d/d2/First_Place_Blue_Ribbon.png",
        "advertisementId": 1,
        "id": 1
    },
    "price": 1.00,
    "id": 1
}
```
```
{
    "adTitle": "FirstAd",
    "description": "FirstDesc",
    "advertisementURIs": [
        {
            "uri": "https://upload.wikimedia.org/wikipedia/commons/d/d2/First_Place_Blue_Ribbon.png",
            "advertisementId": 1,
            "id": 1
        },
        {
            "uri": "https://mma.prnewswire.com/media/1438929/first_Logo.jpg?p=facebook",
            "advertisementId": 1,
            "id": 2
        },
        {
            "uri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAVWQdMgjsblEZEp8Oq6EGCVVuWcvOlBtYwDZ081vrczG_r6LbCWoqc0ijwAhyO6PhKng&usqp=CAU",
            "advertisementId": 1,
            "id": 3
        }
    ],
    "price": 1.00,
    "id": 1
}
```
*Fail response:*
```
{
    "addId": null,
    "resultCode": 400,
    "message": "Invalid id"
}
```
**GetAll:**

 *Request Url:*
https://advertisementsserviceapi.azurewebsites.net/Api/GetAll

*Parameters*
* int page - indicates the pagination of the collection of all elements(by default page_size = 10 elements), optional parametеr(by default = 1)
* string field - optional parameter, indicates to the field by which you want to sort the item collection;
fields are now available:

  `price`

  `creation_date`

* bool increase - optional parameter, indicates sorting direction: `increase` or `decrease`

*Example request:*

`https://advertisementsserviceapi.azurewebsites.net/Api/GetAll`

`https://advertisementsserviceapi.azurewebsites.net/Api/GetAll?page=1`

`https://advertisementsserviceapi.azurewebsites.net/Api/GetAll?page=1&field=price`

`https://advertisementsserviceapi.azurewebsites.net/Api/GetAll?page=1&field=price&increase=true`

*Success response:*

```
[
    {
        "adTitle": "FirstAd",
        "imageUri": {
            "uri": "https://upload.wikimedia.org/wikipedia/commons/d/d2/First_Place_Blue_Ribbon.png",
            "advertisementId": 1,
            "id": 1
        },
        "price": 1,
        "id": 1
    },
    {
        "adTitle": "SecondAd",
        "imageUri": {
            "uri": "https://static8.depositphotos.com/1338574/828/i/950/depositphotos_8282211-stock-photo-the-number-2.jpg",
            "advertisementId": 2,
            "id": 4
        },
        "price": 2.2,
        "id": 2
    }
]
```
```
[
    {
        "adTitle": "SecondAd",
        "imageUri": {
            "uri": "https://static8.depositphotos.com/1338574/828/i/950/depositphotos_8282211-stock-photo-the-number-2.jpg",
            "advertisementId": 2,
            "id": 4
        },
        "price": 2.2,
        "id": 2
    },
    {
        "adTitle": "FirstAd",
        "imageUri": {
            "uri": "https://upload.wikimedia.org/wikipedia/commons/d/d2/First_Place_Blue_Ribbon.png",
            "advertisementId": 1,
            "id": 1
        },
        "price": 1,
        "id": 1
    }
]
```
```
[
    {
        "adTitle": "FirstAd",
        "imageUri": {
            "uri": "https://upload.wikimedia.org/wikipedia/commons/d/d2/First_Place_Blue_Ribbon.png",
            "advertisementId": 1,
            "id": 1
        },
        "price": 1,
        "id": 1
    },
    {
        "adTitle": "SecondAd",
        "imageUri": {
            "uri": "https://static8.depositphotos.com/1338574/828/i/950/depositphotos_8282211-stock-photo-the-number-2.jpg",
            "advertisementId": 2,
            "id": 4
        },
        "price": 2.2,
        "id": 2
    }
]
```

*Fail response:*
```
{
    "addId": null,
    "resultCode": 404,
    "message": "Page or items not found"
}
```

 

    

