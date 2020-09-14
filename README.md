# .NET Core - GraphQL


## Install
``` powershell
PM> Install-Package GraphQL -Version 2.4.0
PM> Install-Package GraphQl.AspNetCore -Version 1.1.4
PM> Install-Package GraphQL.AspNetCore.Graphiql -Version 1.1.4
```


## Configure
``` csharp
public void ConfigureServices(IServiceCollection services)
{
    // ..

    services.AddTransient<AuthorType>();
    services.AddTransient<BookType>();
    services.AddTransient<PublisherType>();

    services.AddTransient<AuthorRootType>();
    services.AddTransient<BookRootType>();
    services.AddTransient<PublisherRootType>();
            
    services.AddTransient<RootQuery>();

    services.AddGraphQl(schema =>
    {
        schema.SetQueryType<RootQuery>();
    });

    // ..
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ..
    
    app.UseGraphQl(
        path: "/graphql",
        configure: options =>
        {
            options.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
            options.ExposeExceptions = true;
            options.FormatOutput = false;
        });

    app.UseGraphiql(
        path: "/graphiql",
        configure: options =>
        {
            options.GraphQlEndpoint = "/graphql";
        });
    
    // ..
}
```


## Usage
### **Get all authors**
#### REST
``` graphql
[GET] /api/v1/authors
```
``` json
[
  {
    "id": 1,
    "name": ".."
  }
]
```
#### GraphQL
``` graphql
[POST] /graphql

{
  authors {
    id
    name
  }
}
```
``` json
{
  "data": {
    "authors": [
      {
        "id": 1,
        "name": ".."
      }
    ]
  }
}
```

---

### **Get author by ID**
#### REST
``` graphql
[GET] /api/v1/authors/1
```
``` json
{
  "id": 1,
  "name": ".."
}
```
#### GraphQL
``` graphql
[POST] /graphql

{
  authorById(id: 1) {
    id
    name
  }
}
```
``` json
{
  "data": {
    "authorById": {
      "id": 1,
      "name": ".."
    }
  }
}
```

---

### **Get all books**
#### REST
``` graphql
[GET] /api/v1/books
```
``` json
[
  {
    "isbn": "..",
    "title": "..",
    "subTitle": "..",
    "description": "..",
    "pages": 1,
    "publishedAt": "..",
    "author": {
      "id": 1,
      "name": ".."
    },
    "publisher": {
      "id": 1,
      "name": ".."
    }
  }
]
```
#### GraphQL
``` graphql
[POST] /graphql

{
  books {
    isbn
    title
    subTitle
    description
    pages
    publishedAt
    author {
      id
      name
    }
    publisher {
      id
      name
    }
  }
}
```
``` json
{
  "data": {
    "booksByPublisherId": [
      {
        "isbn": "..",
        "title": "..",
        "subTitle": "..",
        "description": "..",
        "pages": 1,
        "publishedAt": "..",
        "author": {
          "id": 1,
          "name": ".."
        },
        "publisher": {
          "id": 1,
          "name": ".."
        }
      }
    ]
  }
}
```

---

### **Get book by ISBN**
#### REST
``` graphql
[GET] /api/v1/books/1234567890123
```
``` json
{
  "isbn": "1234567890123",
  "title": "..",
  "subTitle": "..",
  "description": "..",
  "pages": 1,
  "publishedAt": "..",
  "author": {
    "id": 1,
    "name": ".."
  },
  "publisher": {
    "id": 1,
    "name": ".."
  }
}
```
#### GraphQL
``` graphql
[POST] /graphql

{
  bookByIsbn(isbn: "1234567890123") {
    isbn
    title
    subTitle
    description
    pages
    publishedAt
    author {
      id
      name
    }
    publisher {
      id
      name
    }
  }
}
```
``` json
{
  "data": {
    "bookByIsbn": {
      "isbn": "1234567890123",
      "title": "..",
      "subTitle": "..",
      "description": "..",
      "pages": 1,
      "publishedAt": ",,",
      "author": {
        "id": 1,
        "name": ".."
      },
      "publisher": {
        "id": 1,
        "name": ".."
      }
    }
  }
}
```

---

### **Get books by author ID**
#### REST
``` graphql
[GET] /api/v1/authors/1/books
```
``` json
[
  {
    "isbn": "..",
    "title": "..",
    "subTitle": "..",
    "description": "..",
    "pages": 1,
    "publishedAt": "..",
    "author": {
      "id": 1,
      "name": ".."
    },
    "publisher": {
      "id": 1,
      "name": ".."
    }
  }
]
```
#### GraphQL
``` graphql
[POST] /graphql

{
  booksByAuthorId(id: 1) {
    isbn
    title
    subTitle
    description
    pages
    publishedAt
    author {
      id
      name
    }
    publisher {
      id
      name
    }
  }
}
```
``` json
{
  "data": {
    "booksByAuthorId": [
      {
        "isbn": "..",
        "title": "..",
        "subTitle": "..",
        "description": "..",
        "pages": 1,
        "publishedAt": "..",
        "author": {
          "id": 1,
          "name": ".."
        },
        "publisher": {
          "id": 1,
          "name": ".."
        }
      }
    ]
  }
}
```

---

### **Get books by publisher ID**
#### REST
``` graphql
[GET] /api/v1/publishers/1/books
```
``` json
[
  {
    "isbn": "..",
    "title": "..",
    "subTitle": "..",
    "description": "..",
    "pages": 1,
    "publishedAt": "..",
    "author": {
      "id": 1,
      "name": ".."
    },
    "publisher": {
      "id": 1,
      "name": ".."
    }
  }
]
```
#### GraphQL
``` graphql
[POST] /graphql

{
  booksByPublisherId(id: 1) {
    isbn
    title
    subTitle
    description
    pages
    publishedAt
    author {
      id
      name
    }
    publisher {
      id
      name
    }
  }
}

```
``` json
{
  "data": {
    "booksByPublisherId": [
      {
        "isbn": "..",
        "title": "..",
        "subTitle": "..",
        "description": "..",
        "pages": 1,
        "publishedAt": "..",
        "author": {
          "id": 1,
          "name": ".."
        },
        "publisher": {
          "id": 1,
          "name": ".."
        }
      }
    ]
  }
}
```

---

### **Get all publishers**
#### REST
``` graphql
[GET] /api/v1/publishers
```
``` json
[
  {
    "id": 1,
    "name": ".."
  }
]
```
#### GraphQL
``` graphql
[POST] /graphql

{
  publishers {
    id
    name
  }
}
```
``` json
{
  "data": {
    "publishers": [
      {
        "id": 1,
        "name": ".."
      }
    ]
  }
}
```

---

### **Get publisher by ID**
#### REST
``` graphql
[GET] /api/v1/publishers/1
```
``` json
{
    "id": 1,
    "name": ".."
}
```
#### GraphQL
``` graphql
[POST] /graphql

{
  publisherById(id: 1) {
    id
    name
  }
}
```
``` json
{
  "data": {
    "publisherById": {
      "id": 1,
      "name": ".."
    }
  }
}
```

## Credits
* [graphql-dotnet](https://github.com/graphql-dotnet/graphql-dotnet)
* [graphql-aspnetcore](https://github.com/JuergenGutsch/graphql-aspnetcore)
