> ```
>██████╗ ██╗███████╗ █████╗ ██████╗ ██╗     ███████╗██████╗ ████████╗███████╗ ██████╗██╗  ██╗
>██╔══██╗██║██╔════╝██╔══██╗██╔══██╗██║     ██╔════╝██╔══██╗╚══██╔══╝██╔════╝██╔════╝██║  ██║
>██║  ██║██║███████╗███████║██████╔╝██║     █████╗  ██║  ██║   ██║   █████╗  ██║     ███████║
>██║  ██║██║╚════██║██╔══██║██╔══██╗██║     ██╔══╝  ██║  ██║   ██║   ██╔══╝  ██║     ██╔══██║
>██████╔╝██║███████║██║  ██║██████╔╝███████╗███████╗██████╔╝   ██║   ███████╗╚██████╗██║  ██║
>╚═════╝ ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚══════╝╚═════╝    ╚═╝   ╚══════╝ ╚═════╝╚═╝  ╚═╝
> ```

## Team Name

DisabledTech

## Repo location URL

[REPO](https://github.com/soft-eng-practicum/disabledTech) - Click this link to quickly go back to our repository.

## Process tool and URL

* [Android Studio](https://developer.android.com/studio/index.html) - Android Studio is the official integrated development environment for Google's Android operating system, built on JetBrains' IntelliJ IDEA software and designed specifically for Android development.
* [Visual Studio](https://www.visualstudio.com/) - Microsoft Visual Studio is an integrated development environment from Microsoft. It is used to develop computer programs for Microsoft Windows, as well as web sites, web apps, web services and mobile apps.
* [Atom](https://atom.io/) - Atom is a free and open-source text and source code editor for macOS, Linux, and Microsoft Windows with support for plug-ins written in Node.js, and embedded Git Control, developed by GitHub.
* [SQLite](https://www.sqlite.org/) - SQLite is a relational database management system contained in a C programming library. In contrast to many other database management systems, SQLite is not a client–server database engine. Rather, it is embedded into the end program.
* [Bluetooth](https://www.bluetooth.com/) - Bluetooth is a wireless technology standard for exchanging data over short distances from fixed and mobile devices, and building personal area networks.
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/csharp) - C# is a programming language encompassing strong typing, imperative, declarative, functional, generic, object-oriented, and component-oriented programming disciplines.
* [JAVA](http://docs.oracle.com/javase/8/) - Java is a general-purpose computer programming language that is concurrent, class-based, object-oriented, and specifically designed to have as few implementation dependencies as possible.
* [Electron](https://electronjs.org/) - Electron is an open-source framework created by Cheng Zhao, and now developed by GitHub. It allows for the development of desktop GUI applications using front and back end components.

## Communication tool

[Slack](https://ggc-dev.slack.com/messages/C6R5CJVC6/) - Want a sneak peak at our brainstorming process?  Check out our slack channel here!

## Authors

1. **Aaron Knobloch** - Lead Programmer / Team Manager - [aknobloch](https://github.com/aknobloch)
2. **Jeff Graves** - Lead Tester / Document Lead - [giJeff](https://github.com/giJeff)
3. **Taylor Brust** - *UI/UX Lead* - [tbrustggc](https://github.com/tbrustggc)
4. **Tobin Michael Crone** - Data Modeling - [tobincrone](https://github.com/tobincrone)

See also the list of [contributors](https://github.com/soft-eng-practicum/disabledTech/graphs/contributors) who participated in this project.


# Intro

Hello and welcome!  

It's currently 2017 and there are so many amazing keyboard shortcuts to make our lives easier.  Some of these shortcuts can require a few keys to be pressed simultaneously or even a long key press such as clicking and dragging the mouse.  We are aware and troubled that these events can be difficult for some users.  DisabledTech is here to harness the power of technology and give all users equal power behind a keyboard.  We will start off by creating a mobile app, android first, that will allow users to pick from a pre-built library of commands or create and send their own custom commands from a phone app to a windows system.  These big beautiful buttons that our app provides will be an elegant and simple alternative to those pesky complex keyboard shortcuts.  All this and an easy to use user interface this app is intended for use and will benefit all users.

## Getting Started

To get started adding features and functionality to this app start by forking, cloning, or downloading.  You can then chose to import the projects into our favorite IDEs.  We are using [Android Studio](https://developer.android.com/studio/index.html), [Visual Studio](https://www.visualstudio.com/), and [Atom](https://atom.io/) during this project.  

### Setup guidelines
```
Setting up Windows server dependencies:
* Prerequisites
	1. Visual Studio 2017 with the .NET desktop development package.
```
1. First, download the latest 32Feet.NET library from [here](https://32feet.codeplex.com/releases/view/88941) 
2. Run the setup files for the library. It will likely require you to install an older version of the .NET framework in the installer. The library (as of writing) runs on .NET 3.5, while our project is built with a later version. You need both, but they are intercompatible. 
* *warning* The installer may give you an error that the MS Help 2.X runtime is not installed. If you care about Help files, you can try to solve that. I don't, so I didn't and it was fine. 
3. Afterwards, open the project solution file. 

```
To set up the database in Visual Studio you will need to:
```
* right click references > manage NuGET > browse > SQLite.Net-PCL > install
* download sqlite3 dll from http://www.sqlite.org/download.html and copy it into bin/Debug folder

```
To work with the Electron Windows GUI:
```
* You'll need the node_modules folder and all its contents.
* run the following command in the cmd prompt to start the app IF you have node and NPM globally installed.  
.\node_modules\.bin\electron .
* However if neither are installed please look for an [online install guide](http://blog.teamtreehouse.com/install-node-js-npm-windows)


### Installing

There must be something to install

```
Before I can tell you how to install
```

## Contributing

Please read [CONTRIBUTING.md](https://github.com/soft-eng-practicum/disabledTech/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [GitHub](http://github.com/) for versioning. For the versions available, see the [tags on this repository](https://github.com/soft-eng-practicum/disabledTech/tags). 

## License

GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007

## Acknowledgments

* Thank you Scott Warfield for being our client
