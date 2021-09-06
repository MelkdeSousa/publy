# publy

Webapp to publicize your company's contributors profile

## Project Scope

- Theme:

  > The project consists of creating a WebApp to disseminate the profile of contributors within the company, where in the initial scope we will need to implement a CRUD of people (contributors) organized by departments, which can be implemented in the company so that all contributors can have access to the profile of colleagues.


## Requirements

  - [x] Diagram Entity-Relationship (DER)
  - [x] API Restful in .NET Core 5
  - [x] PostgreSQL with Entity Framework (ORM)
  - CRUD of Entities:
      - [x] Collaborator:
          - id
          - name
          - email
          - age
          - password
          - status (active/inactive)
          - department
          - groups
          - social networks
          - description profile
      - [] Group & Department:
          - id
          - name
  - [x] Consider that: A collaborator MUST be related to one or more departments - where the existing departments are:
      - FINANCEIRO
      - ADMINISTRAÇÃO
      - DIREÇÃO
      - OPERACIONAL
      - INFRAESTRUTURA
      - DESENVOLVIMENTO
      - COMERCIAL
  - [] Consider that: The collaborator **MUST be associated with at *least one group*** - where the initial existing groups are:
      - CLT
      - PJ
      - FREELANCER
      - PARCEIROS
      - OUTROS

## Tips

- The candidate will be able to define the organization that he/she deems most suitable for the project, however, it is advisable to have at least the following layers:
    - [x] Controller (facade layer responsible for implementing the API)
    - [x] Services (services layer responsible for implementing use case and services)
    - [x] Repository (persistency layer responsible for implementing database communication and operations)

##  Differentials

  - [x] Swagger;
  - [x] AutoMapper to create DTOs
  - [x] OO: Classes, Interfaces, Polymorphism, Encapsulation, Abstraction
  - Parameterization to perform search filter in the reading API using the "name" field as a clause.
  - Test (NUnit)
  - Deploy with Docker Containers
