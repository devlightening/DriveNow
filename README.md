# DriveNow

<p>
  <img alt=".NET" src="https://img.shields.io/badge/ASP.NET%20Core-Web%20API%20%2B%20MVC-512BD4?logo=dotnet&logoColor=white">
  <img alt="EF Core" src="https://img.shields.io/badge/EF%20Core-SQL%20Server-512BD4">
  <img alt="Architecture" src="https://img.shields.io/badge/Onion-Architecture-1f6feb">
  <img alt="CQRS" src="https://img.shields.io/badge/CQRS-MediatR-orange">
</p>

An online **car rental platform** built to practice **Onion Architecture**, **CQRS** and the **Mediator pattern** in a realistic multi-project solution: a public Web API plus an MVC web site with a public front and an admin panel.

## Architecture

```text
Presentation/DriveNow.WebAPI      REST controllers (cars, brands, categories, pricing, blogs, ...)
Frontends/DriveNow.WebUI          ASP.NET Core MVC site: public pages + admin area
Frontends/DriveNow.Dtos           DTOs shared by the web UI
Core/DriveNow.Application         use cases: commands, queries, handlers, results
Core/DriveNow.Domain              entities (Car, Brand, Blog, Author, Pricing, Location, ...)
Infrastructure/DriveNow.Persistance   EF Core (SQL Server) context, repositories and migrations
```

Dependencies point inward: Domain has no project references, Application depends on Domain, and Persistance depends on Application and Domain. The Web API depends on Persistance, and the MVC site depends on Application and the shared DTOs.

The Application layer shows **two ways of doing the same separation**:

- `Features/CQRS` — hand-written command/query/handler classes (cars, brands, categories, about, contact)
- `Features/Mediator` — the same idea with **MediatR** (blogs, authors, banners, comments, pricing, locations, services, testimonials)

## What the product does

- Car catalog with brands, categories, features, pricing per period, and publish/unpublish
- Locations, services, testimonials, banners and contact messages
- Blog with authors, contents, comments, tags and slug routing
- Admin area to manage all of the above

## Run it

Requires the .NET SDK and SQL Server (LocalDB or Express).

1. Set the `DefaultConnection` connection string in `Presentation/DriveNow.WebAPI/appsettings.json` to your own SQL Server instance.
2. Apply the EF Core migrations, or create the database from the context.
3. Start both projects:

```bash
dotnet run --project Presentation/DriveNow.WebAPI
dotnet run --project Frontends/DriveNow.WebUI
```

## Known limits

- Learning project: there are no automated tests and no CI yet.
- Authentication is not implemented in the API.
- The web UI is built on ready-made front-end templates (public site and admin panel), so most of the file count is static assets.

## Author

**Halil İbrahim Yıldırım** — .NET backend developer · [GitHub](https://github.com/devlightening) · [LinkedIn](https://www.linkedin.com/in/0001myprofile)
