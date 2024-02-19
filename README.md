# vancouver-stock-exchange

Creating a Stock Exchange Simulation using .NET. Complete with buy sell orders and an orderbook.

## Design Decisions

Used Clean Architecture to separate project into layers. Those layers are Infrastructure layer (responsible for external tools), API layer (responsible for handling http requests), Application layer (responsible for business logic), Domain layer (responsible for defining domain entities). All dependencies flow inwards which helps makes outer layers more modular and easier to adapt.

![Test Image 6](CleanArchitecture.png)


### Algorithm/Data Structure for Orderbook

Considering using sorted set and linkedlist to create orderbook.

## Tech Stack

- **.NET**
  - Created api that can receive buy and sell orders
  - Entity Framwork to query the SQL database

## How to run

1. Navigate to Exchange.API folder

2. Run `dotnet run`
