<!-- PROJECT SHIELDS -->
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Issues][issues-shield]][issues-url]

<!-- PROJECT LOGO -->
<br />
<!-- <p align="center">
  <a href="https://github.com/em-jones/WidgetMarketplace">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

   <h3 align="center">Widget Marketplace</h3>
</p>
-->

<h3 align="center">Widget Marketplace</h3>
<p align="center">
    <br />
    <!-- <a href="https://github.com/em-jones/WidgetMarketplace"><strong>Explore the docs »</strong></a> -->
    <br />
    <br />
    <!--<a href="https://github.com/em-jones/WidgetMarketplace">View Demo</a>-->
    <a href="https://github.com/em-jones/WidgetMarketplace/issues">Report Bug</a>
    ·
    <a href="https://github.com/em-jones/WidgetMarketplace/issues">Request Feature</a>
  </p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
<!--
[![Product Name Screen Shot][product-screenshot]](https://example.com)
-->

Items of particular note:
The project combines a number of concepts that are intended to be used as reference patterns
for a .NET ecosystem application.

### Built With

#### Technologies
* [Docker](https://www.docker.com)
* [C# 9](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)
  * [Records](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types)
  * [Pattern Matching Switch expressions](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions)
  * [LINQ Collection Operations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
* [.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis) // RESTful HTTP interface
* [Orleans Project]()
* [Mediatr](https://github.com/jbogard/MediatR)
* [Language Ext](https://github.com/louthy/language-ext) // Functional Type System for C# - including monads, lenses, and delegates

#### Patterns
- Interfaces Module meant to be decoupled at a top-level `namespace` as a manner of identifying independently-deployable _modules_ (`Core`)
- DDD `Bounded Contexts`
    - `Anti-Corruption Layer`(`ACL`)s for integrating across bounded contexts - defined by `*ACL` _modules_
    - ``
- Onion Architecture
  - `Infrastructure` layer consistent of the `ServiceHost` and `Data` namespaces
  - `Application` layer consistent of `Controller` implementations and `Mediator Colleagues` 
  - `Domain` Layer consistent of the `*Store`(`Event Store`),  `*Exceptions`
- Eventually consistent data stores
- CQR-segregated namespaces 
  - `Event Stores` for `Command`(`Write`) operations
  - `Projections` for `Query`(`Read`) view management
  - [Reference](https://www.c-sharpcorner.com/article/onion-architecture-in-asp-net-core-mvc/)
<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

* [Docker](https://www.docker.com)
* [Make](https://www.gnu.org/software/make/)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/em-jones/WidgetMarketplace.git
   ```
2. Run make commands
   ```sh
   make up
   ```
3. Check out the nifty OpenAPI spec at [localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/em-jones/WidgetMarketplace/issues) for a list of proposed features (and known issues).

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- CONTACT -->
## Contact

Em Jones - emjonesdev@gmail.com

Project Link: [https://github.com/em-jones/WidgetMarketplace](https://github.com/em-jones/WidgetMarketplace)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* [Best-README-Template](https://github.com/othneildrew/Best-README-Template)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/em-jones/repo.svg?style=for-the-badge
[contributors-url]: https://github.com/em-jones/repo/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/em-jones/repo.svg?style=for-the-badge
[forks-url]: https://github.com/em-jones/repo/network/members
[stars-shield]: https://img.shields.io/github/stars/em-jones/repo.svg?style=for-the-badge
[stars-url]: https://github.com/em-jones/repo/stargazers
[issues-shield]: https://img.shields.io/github/issues/em-jones/WidgetMarketplace.svg?style=for-the-badge
[issues-url]: https://github.com/em-jones/WidgetMarketplace/issues
[license-shield]: https://img.shields.io/github/license/em-jones/repo.svg?style=for-the-badge
[license-url]: https://github.com/em-jones/repo/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/emgjones