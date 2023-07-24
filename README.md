# Product Review API Readme

This is a product review API built in C# and MongoDB. The API allows you to perform CRUD operations on product reviews.

## Requirements

- C# 
- MongoDB

## Installation

1. Clone the repository
2. Install the required packages using NuGet package manager
3. Update the `appsettings.json` file with your MongoDB connection string and database name.

## Usage

The API has the following endpoints:

- `GET /reviews` - Returns all reviews
- `GET /reviews/{id}` - Returns a specific review by ID
- `POST /reviews` - Creates a new review
- `PUT /reviews/{id}` - Updates an existing review by ID
- `DELETE /reviews/{id}` - Deletes a review by ID

