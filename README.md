# Movie Manager API

![build](https://github.com/hk-modding/api/actions/workflows/build.yaml/badge.svg)
![docs](https://github.com/hk-modding/api/actions/workflows/docs.yaml/badge.svg)
![GitHub all releases](https://img.shields.io/github/downloads/hk-modding/api/total)

This is an API for managing movies in a movie theater. It includes a login service for user authentication.

# Technologies Used

* .NET
* Entity Framework
* JSON Web Tokens (JWT)
* MySQL

# Setup

To run this project locally, you'll need to have .NET and MySQL installed on your machine.

* Clone the repository: git clone https://github.com/Gabriel-283/Movie_Manager_API.git

* When application run, the migrations go to apply in data base connection in appsettings.json

# API Documentation


## Authentication

<details>
<summary>Register new User</summary>

```
curl --location 'https://localhost:6001/Registration' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserName": "Gabriel",
    "Email": "bernardogabriel334@gmail.com",
    "Password":"Teste@123",
    "PasswordConfirm": "Teste@123",
    "Role":1
}'

```
</details>

<details>
<summary>Login</summary>

```
curl --location 'https://localhost:6001/Login' \
--header 'teste: valor' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Email": "bernardogabriel334@gmail.com",
    "Password": "Teste@123"
}'

```
</details>

<details>
<summary>Request Password reset</summary>

```
curl --location 'https://localhost:6001/password-reset' \
--header 'Content-Type: application/json' \
--data-raw ' {
      "Email": "admin@admin.com"
 }
'

```
</details>

<details>
<summary>Set new password</summary>

```
curl --location 'https://localhost:6001/set-new-password' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Email":"admin@admin.com",
    "Password":"Teste@123",
    "RePassword":"Teste@123",
    "Token":"CfDJ8CpZLVfMDJ1OtH7FpIxuarr7XgHuBGw1sjXYSoSWOeT5dLfrsfH962fC5dMCK9FBCfzxHqtX0y0AmeIfLp4iwMUlTCKWe0moDHglaXFoDWyDsF6RWUkGjBt4J38jNG22vdl5+LS71npDdO/3TrKEQTAHp3invh4t/QFLnBtT59n2jRJAB0KRDc+9Sftxhxq09pOZnw2b84OPjEHIIhNbGMM="
}'
```
</details>

# Movie API

<details>
<summary>List Movies</summary>

```
curl --location 'https://localhost:5001/Movie'

```
</details>

<details>
<summary>List Movie Teaters</summary>

```
curl --location 'https://localhost:5001/MovieTheater/'

```
</details>


<details>
<summary>List Sessions</summary>

```
curl --location 'https://localhost:5001/Session/'

```
</details>

<details>
<summary>List Movie Theater Managers</summary>

```
curl --location --request GET 'https://localhost:5001/MovieTheaterManager/' \
--header 'Content-Type: application/json' \
--data '{
    "Name":"teste"
}'

```
</details>

<details>
<summary>Create new session</summary>

```
curl --location 'https://localhost:5001/Session/' \
--header 'Content-Type: application/json' \
--data '{
    "MovieId": 1,
    "MovieTheaterId": 2,
    "EndSession" : "2022-09-07T21:00:00Z"
}'

```
</details>


<details>
<summary>Create new Movie</summary>

```
curl --location 'https://localhost:5001/Movie' \
--header 'accept: text/plain' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6IkdhYnJpZWxfU291emEiLCJpZCI6IjEwMDAwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9kYXRlb2ZiaXJ0aCI6IjAxLzAxLzAwMDEgMDA6MDA6MDAiLCJleHAiOjE2NjcyNjcwMjR9._Qw32qwMZvUbkkU7XA7gVBUAxyKdcgDf9XTlBmKChQg' \
--header 'Content-Type: application/json' \
--data '{
    "Title":"Todo Mundo em Panico",
    "Director" : "Sean Cunningham",
    "MovieKind" : "Comedia",
    "Duration" : 152,
    "Description" : "filme de teste"
}'

```
</details>


<details>
<summary>Create new Movie Theater</summary>

```
curl --location 'https://localhost:5001/MovieTheater/' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6IkdhYnJpZWxfU291emEiLCJpZCI6IjEwMDA0IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9kYXRlb2ZiaXJ0aCI6IjAxLzAxLzAwMDEgMDA6MDA6MDAiLCJleHAiOjE2NzczODEzOTZ9.NSURouV7hq4Q3oYGWa0a447CkUYNC9PcmkxGAI6G-og' \
--header 'Content-Type: application/json' \
--data '{
    "Name": "Cinema de teste inicial",
    "AddressId" : 5,
    "MovieTheaterManagerId":1
}'

```
</details>

<details>
<summary>Create new address</summary>

```
curl --location 'https://localhost:5001/Adress/' \
--header 'Content-Type: application/json' \
--data '{
    "Number" : 1545893,
    "ZipCode" : 25861930,
    "Street" : "Rua das Pitanoogueiras",
    "Neighborhood" : "Jardim das Pitanmjgueiras"
}'

```
</details>

<details>
<summary>Delete session</summary>

```
curl --location --request DELETE 'https://localhost:5001/Session/1'

```
</details>

<details>
<summary>Create new Movie Theater Manager </summary>

```
curl --location 'https://localhost:5001/MovieTheaterManager/' \
--header 'Content-Type: application/json' \
--data '{
    "Name": "Teste"

}'

```
</details>


<details>
<summary>Get Address by ID </summary>

```
curl --location 'https://localhost:5001/Adress/1'

```
</details>

# Error Handling
If an error occurs while processing a request, the server will return an HTTP status code and an error message in JSON format. The HTTP status code will indicate the type of error that occurred.

# Security
This API uses encrypt to securely hash user passwords before storing them in the database. It also uses JWT tokens for user authentication, which help protect against cross-site scripting (XSS) and cross-site request forgery (CSRF) attacks.

# Conclusion
That's it! With this API, you can easily manage movies in a movie theater, while also providing secure user authentication. If you have any questions or feedback, feel free to contact us at example@example.com.
