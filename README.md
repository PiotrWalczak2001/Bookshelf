# Bookshelf

Project example Asp.Net Core Api + Blazor WebAssembly client side of application that looks like netflix or spotify but with books.

## Tech Stack

- Asp.Net Core
- Blazor WebAssembly UI
- Entity Framework
- Web API
- Clean Architecture
- CQRS
- AutoMapper
- FluentValidation
- Authentication and Authorization
- JWT Token
- Swagger
- And more...

## Current Features

- Login/Register/Logout
- Book/Category/Shelves CRUD
- Adding/Removing books to shelves by API but not yet in Blazor App

## Features to do

- Reading books from pdf (maybe with ironpdf or something else)
- Roles like administrator that can manage Books and Categories
- Searching by categories/authors/title and tags (searching filters)
- Subcriber role with confirming mailing by sendgrid
- Following categories with notifications when new book is added to database
- And I come up with something else

### Entities

- Base entity
- Book
- Category
- Shelf
- Shelfbook (shelfbook is  entity that is stored in shelves)
- ApplicationUser

### Controllers

- AccountController (authenticate/register
- BookController (Getting all books / book details by Id / adding new book / deleting / updating)
- CategoryController (Getting all categories / category details by Id / adding new category / deleting) 
- ShelfController (Getting all shelves / user shelf by Id / adding new shelf / deleting updating / adding shelfbooks to shlef and removing)