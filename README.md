# Tunify Platform

## Brief Description

Tunify is a comprehensive music streaming platform that allows users to create and manage playlists, explore a diverse library of songs, albums, and artists, and enjoy personalized recommendations based on their preferences. The platform supports multiple subscription types, catering to various user needs. Tunify aims to deliver an exceptional music experience through a user-friendly interface and robust backend infrastructure.

## Tunify ERD Diagram

![Tunify ERD](TunifyPlatform/tunify.png)

## Overview of Relationships

The Tunify platform's database is designed with several entities to efficiently manage and store information related to users, subscriptions, playlists, songs, albums, and artists. Below is an overview of the relationships between these entities:

1. **Users and Subscriptions**
   - **Users** are linked to **Subscriptions** through a foreign key relationship. Each user has a `SubscriptionId` that references the `Id` of a subscription plan. This relationship ensures that each user is associated with a specific subscription type, which defines their access level and features on the platform.
   - **One-to-Many Relationship**: One subscription can have multiple users, but each user can only have one subscription.

2. **Users and Playlists**
   - **Users** can create multiple **Playlists**. Each playlist is linked to a user through a foreign key (`UserId`).
   - **One-to-Many Relationship**: One user can have multiple playlists, but each playlist is associated with one user.

3. **Playlists and Songs**
   - The relationship between **Playlists** and **Songs** is managed through a join table called `PlaylistSongs`. This table contains the foreign keys for both playlists and songs, allowing a many-to-many relationship.
   - **Many-to-Many Relationship**: One playlist can contain multiple songs, and one song can appear in multiple playlists.

4. **Songs and Albums**
   - Each **Song** belongs to an **Album**. The `AlbumId` in the Songs table references the `Id` in the Albums table.
   - **One-to-Many Relationship**: One album can have multiple songs, but each song belongs to one album.

5. **Songs and Artists**
   - Each **Song** is created by an **Artist**. The `ArtistId` in the Songs table references the `Id` in the Artists table.
   - **One-to-Many Relationship**: One artist can create multiple songs, but each song is created by one artist.


---


## Repository Design Pattern

### Overview
The Repository Design Pattern decouples data access logic from the business logic in the application, promoting modularity and testability.

### Implementation
In this project, repositories were created for managing data access for the `Users`, `Playlist`, `Song`, and `Artist` entities. These repositories encapsulate CRUD operations and any additional data access logic, making the application easier to maintain and extend.

### Benefits
- **Separation of Concerns**: Keeps data access logic separate from business logic.
- **Testability**: Allows for mocking data access during unit tests.
- **Flexibility**: Facilitates changes in data access strategy without affecting business logic.

## New Navigation and Routing Functionalities

In this lab, we introduced advanced navigation and routing functionalities to improve the user experience within the **Tunify Platform**. These enhancements include:

- **Dynamic Routing**: Routes are dynamically generated based on user actions such as playlist creation or artist selection.
- **Nested Routing**: Certain pages, such as songs within a playlist or albums by an artist, use nested routes to keep the URL structure clean and meaningful.
- **Parameterized Routing**: Routes now accept dynamic parameters for accessing specific resources. For example:
  - `/playlists/:id/songs` for viewing songs in a playlist.
  - `/artists/:id/songs` for viewing songs by a particular artist.
- **Lazy Loading**: Implemented lazy loading for certain modules to improve performance, loading only the necessary components when they are needed.

### Sample Route Definitions:
	```javascript
	{
	  path: 'playlists/:id/songs',
	 component: PlaylistSongsComponent,
	},
	{
	  path: 'artists/:id/songs',
	  component: ArtistSongsComponent,
	}

## Swagger UI Integration

### Overview
Swagger UI has been integrated into this project to provide an interactive interface for testing and documenting the API endpoints. This allows developers to easily explore the API's functionality, test requests, and view responses directly from the browser.

### Accessing Swagger UI

1. **Run the Application**
   - Open a terminal or use Visual Studio to run the application. The app will run on `http://localhost:5002/` by default.

	 Using the terminal:
	```bash
	dotnet run

2. **Open Swagger UI**
   - Open your browser and navigate to:
	
	   Using the terminal:
		```bash	
		 http://localhost:5002/

    - The Swagger UI will display a list of all available API endpoints along with the supported HTTP methods (GET, POST, PUT, DELETE).


## Identity:

This section covers the Identity Management implementation in the Tunify Platform. It includes user authentication, role management, and session handling using ASP.NET Core Identity.

### Features

- **User Registration**: Allows new users to sign up with their details.
- **User Login and Logout**: Provides authentication and session management for users.
- **Role Management**: Supports user roles and claims for authorization.
- **Session Management**: Handles user sessions and token-based authentication.

# Lab 15: JWT Authentication and Authorization

## Setup JWT Authentication
1. Install `Microsoft.AspNetCore.Authentication.JwtBearer` package.
2. Configure JWT authentication in `Program.cs`.
3. Implement `JwtTokenService` for token creation and validation.

## Secure API Endpoints
1. Add `[Authorize]` attributes to secure API endpoints.
2. Use role-based and policy-based authorization as needed.

## Manage Roles and Claims
1. Seed initial roles and a default admin user in `TunifyDbContext`.
2. Assign roles and claims to users and secure endpoints based on these roles.
