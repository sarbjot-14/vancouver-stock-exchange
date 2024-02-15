# Vancouver Stock Exchange



## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@john.doe",
  "password": "mysecretpassword"
}
```

```js
200 OK
```

#### Register Response

```json
{
  "id": "6b11a84f-a07d-4319-8648-37b5020862f6",
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@john.doe",
  "token": "eyJhbGciOiJIUzI1(...)"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "johndoe@john.doe",
  "password": "mysecretpassword"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "6b11a84f-a07d-4319-8648-37b5020862f6",
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@john.doe",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2YjExYTg0Zi1(...)"
}
```
