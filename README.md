# Rent A Car Backend Api .Net Core 3.1

## 📌 Usage 

1-) Open the project in VS19 or other version.

2-) Open the terminal. Enter into folder with command  "cd webapi"

3-) Run the project with command "dotnet run --urls=https://localhost:44383"

4-) For API usage,  "https://localhost:44383/swagger" enter into  the url field

![swaggerui](https://github.com/kaansen57/RentaCar-Backend/blob/master/swagger.png?raw=true)

## 📌 Example

Url : " https://localhost:44383/api/cars/details "

## 📌 Output 
```json
  {
	"data":[
                {
                  "id":1,
                  "carName":"Cla 180",
                  "brandId":1,
                  "brandName":"Mercedes",
                  "colorId":1,
                  "colorName":"Siyah",
                  "dailyPrice":300,
                  "carPropertyId":2,
                  "modelYear":"2015",
                  "findexScore":1500
                }
              ],
	"success":true,
	"message":null}

```