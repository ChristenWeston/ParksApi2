# Parks :national_park: API :mountain:
:desert: :leaves: :volcano: :deciduous_tree:
:butterfly: :gorilla: :owl: :monkey: :eagle: :zebra: :duck: :hippopotamus: :crocodile: :rhinoceros: :whale: :sloth: :snail:

### Created by Christen Weston
#### Authorization help from https://codeburst.io/api-security-in-swagger-f2afff82fb8e and https://jasonwatmore.com/post/2021/04/30/net-5-jwt-authentication-tutorial-with-example-api

#### A National Park API! Now! With JWT Authorization

### Authorize Yourself
1. Use the POST /Account/login route to sign in. You can use any name or password. Make sure they are at least 5 characters or more.
2. Copy the `jwtToken` value from the response
3. Click the "Authorize" button
4. Paste the `jwtToken` value from step 2 into the 'Value' box for Bearer token
5. Your all signed in! You'll notice the locks will all be closed now, indicating you are signed in

## Park API Endpoints

#### Get all parks

```http
GET /api/parks
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name` | `string` |  name of National Park |
| `size` | `int` |  size of National Park (in square miles)|
| `country` | `string` |  country the National Park is located|

#### Get specific park

```http
GET /api/parks/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required** ParkId |

#### Get LargestPark()
``` http
GET /api/parks/LargestPark
```

Returns the National Park with the largest size (in square miles)

#### Get SortByCountry()
``` http
GET /api/parks/SortByCountry
```

Returns a list of all National Parks, sorted by country

#### Get MostParks()
``` http
GET /api/parks/MostParks
```
**Requires** Authorization . See the Authorize Yourself section at the top of the README for instructions
Returns a list of Parks for the Country with the most parks

#### Post Park

```http
POST /api/parks
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name` | `string` |  **Required** name of National Park |
| `size` | `int` |  **Required** size of National Park (in square miles)|
| `city` | `string` |   city the National Park is located|
| `cstate` | `string` |  state the National Park is located|
| `country` | `string` |  **Required** country the National Park is located|

#### Put Park

```http
PUT /api/parks/${id}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name` | `string` |  name of National Park |
| `size` | `int` |  size of National Park (in square miles)|
| `city` | `string` |   city the National Park is located|
| `cstate` | `string` |  state the National Park is located|
| `country` | `string` |  country the National Park is located|

#### Delete Park

```http
DELETE /api/parks/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required** ParkId |

## Technologies Used :woman_technologist:

* Git
* C#
* .NET 5.0
* MVC
* Entity
* CSS
* SQL
* Swagger Docs

## Setup Installation Requirements :scroll:

1. :white_medium_square:  Clone the ParksApi repository
2. :white_medium_square:  Open in your favorite IDE
3. :white_medium_square:  CD into Parks
4. :white_medium_square:  Ensure MySql workbench is installed on your machine. If needed, please visit this site to download and install: [MySQLWorkBench]("https://www.mysql.com/products/workbench/")

5. :white_medium_square:  Create an appsettings.json
6. :white_medium_square: :keyboard: Add the following to your appsettings.json replacing the ```[YourPasswordHere]``` with your password:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=park_api;uid=root;pwd=[YourPasswordHere];"
  }
}
```
7. :white_medium_square: :keyboard: Install dotnet globally by running "``dotnet tool install --global dotnet-ef``"
8. :white_medium_square: :keyboard: run "``dotnet ef database update``"
9. :white_medium_square: :keyboard: run "``dotnet build``"
10. :white_medium_square: :keyboard: run "``dotnet run``" to use the program
11. :white_medium_square: :keyboard: Go to https://localhost:5001/swagger/ to use the SwaggerDocs
11. :white_medium_square:  Enjoy! :partying_face:

# Known Bugs
None

## Date Published
>April 2022

## License Info
[MIT License](https://opensource.org/licenses/MIT)