<div id="top">

<!-- HEADER STYLE: CLASSIC -->
<div align="center">

<img src="readmeai/assets/logos/blue.svg" width="30%" style="position: relative; top: 0; right: 0;" alt="Project Logo"/>

# LANDMINEGAMEWEB

<em></em>

<!-- BADGES -->
<!-- local repository, no metadata badges. -->

<em>Built with the tools and technologies:</em>

<img src="https://img.shields.io/badge/JSON-000000.svg?style=default&logo=JSON&logoColor=white" alt="JSON">
<img src="https://img.shields.io/badge/EditorConfig-FEFEFE.svg?style=default&logo=EditorConfig&logoColor=black" alt="EditorConfig">
<img src="https://img.shields.io/badge/JavaScript-F7DF1E.svg?style=default&logo=JavaScript&logoColor=black" alt="JavaScript">
<img src="https://img.shields.io/badge/NuGet-004880.svg?style=default&logo=NuGet&logoColor=white" alt="NuGet">
<img src="https://img.shields.io/badge/XML-005FAD.svg?style=default&logo=XML&logoColor=white" alt="XML">

</div>
<br>

---

## Table of Contents

- [Table of Contents](#table-of-contents)
- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
    - [Project Index](#project-index)
- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Usage](#usage)
    - [Testing](#testing)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgments](#acknowledgments)

---

## Overview

LandmineGameWeb is a web-based landmine game with a .NET back-end and React front-end.

---

## Features

|      | Component       | Details                              |
| :--- | :-------------- | :----------------------------------- |
| ⚙️ | **Architecture**  | <ul><li>RESTful .NET API for game interactions</li><li>Currently stateful and designed for one user, this would be resolved if work on the solution is resumed</li></ul> |
| 📄 | **Documentation** | <ul><li>View the README</li><li>Comments for complex code</li></ul> |
| 🔌 | **Integrations**  | <ul><li>Integrates with NuGet for package management</li><li>Supports Visual Studio tooling</li></ul> |
| 🧩 | **Modularity**    | <ul><li>Modular design with separate projects for API and tests</li><li>Uses a .sln file for Visual Studio solution management</li><li>Encapsulation of game logic in dedicated classes</li></ul> |
| 🧪 | **Testing**       | <ul><li>Unit tests defined in separate test projects</li><li>Utilizes Microsoft Test Framework</li><li>Test cases cover critical game functionalities</li></ul> |
| ⚡️ | **Performance**   | <ul><li>Optimized for quick game state updates</li><li>Asynchronous programming patterns used for responsiveness</li></ul> |
| 🛡️ | **Security**      | <ul><li>Basic input validation implemented</li></ul> |
| 📦 | **Dependencies**  | <ul><li>NuGet packages for libraries and tools</li><li>Dependencies managed via .csproj files</li></ul> |
| 🚀 | **Scalability**   | <ul><li>Currently stateful and designed for one user, this would be resolved if work on the solution is resumed</li><li>Potential for horizontal scaling with cloud deployment</li></ul> |

---

## Getting Started

### Prerequisites

This project requires the following dependencies:

- **Programming Language:** CSharp
- **Package Manager:** Nuget

### Installation

Build LandmineGameWeb from the source and intsall dependencies:

1. **Clone the repository:**

    ```sh
    ❯ git clone ../LandmineGameWeb
    ```

2. **Navigate to the project directory:**

    ```sh
    ❯ cd LandmineGameWeb
    ```

3. **Install the dependencies:**

    ```sh
    ❯ dotnet restore
    ```

### Usage

Run the project with:

```sh
dotnet run
```

### Testing

Landminegameweb uses the MSTest.TestFramework test framework. Run the test suite with:

```sh
dotnet test
```

---

## Roadmap

- [X] **`Task 1`**: <strike>Implement a working prototype.</strike>
- [ ] **`Task 2`**: Implement the ability to run concurrent games using the same API instance.

---

## Contributing

- **💬 [Join the Discussions](https://LOCAL/readmeai-runner-api/LandmineGameWeb/discussions)**: Share your insights, provide feedback, or ask questions.
- **🐛 [Report Issues](https://LOCAL/readmeai-runner-api/LandmineGameWeb/issues)**: Submit bugs found or log feature requests for the `LandmineGameWeb` project.
- **💡 Submit Pull Requests**: Review open PRs, and submit your own PRs.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your LOCAL account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone /home/runner/work/readmeai-runner-api/readmeai-runner-api/LandmineGameWeb
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to LOCAL**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://LOCAL{/readmeai-runner-api/LandmineGameWeb/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=readmeai-runner-api/LandmineGameWeb">
   </a>
</p>
</details>

---

## License

Landminegameweb is protected under the [LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

<div align="right">

[![][back-to-top]](#top)

</div>


[back-to-top]: https://img.shields.io/badge/-BACK_TO_TOP-151515?style=flat-square
