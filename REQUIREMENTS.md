Name TBD – Windows Keyboard extension Application
# General Requirements and Game Plan

## Purpose:
The purpose of this application is to provide alternative options to execute common commands and macros in a way convenient for those who may experience difficulty when using shortcuts and similar commands in a Windows operating system. Users will be able to easily execute simple or complex commands at the push of a button by using an easy to read interface providing multiple commands and macros to choose from. Applications running on the currently connected Windows platform can be targeted by the user, while a mobile side application displays the commands and macros that can be executed.


## Scope:
This application will provide all the basic commands and shortcuts that contribute to ease of use in the Windows OS. Users will be given the option to create profiles for specific applications which can be customized to display associated commands. Due to time constraints, the initial release of this product will only include the most basic Windows commands such a cut, copy, or paste, along with a few others. A secure connection between the Windows and Android side application will be vital to keep users safe and secure when executing commands. This product will not allow for complete control over Windows applications, but rather provide an alternative method to execute common Windows commands on targeted applications and areas in the Windows OS. Users will not be able to enter customized commands initially, but will instead create macros that allow them to choose multiple stock commands to be executed in a specified order.
. 

## Prioritization Standards
We will use a simple, yet effective method for prioritizing tasks. "Should-a, would-a, could-a." Tasks are prioritized by things we should (S) do, things that we would or will (W) do if time is permitting, and things that we could or can (C) do but are low impact or tricky to implement. Within these categories, the level of priority is based on the classic [priority impact grid](https://express.servicenow.com/support/wp-content/uploads/2016/06/Impact_urgency_matrix.png). Therefore, a particular requirement or task might have a rating of W3, meaning it is a task that will get done if time is permitting, and within the W category it is a mid-impact. Even a task with a S5 rating will take priority, since it is in a higher class altogether.  

## Goals and Prioritization (Ordered from highest to lowest)
* [S1] Windows application to listen for and dispatch client commands.
* [S1] Android command interface for user execution.
* [S1] Connection from mobile devices to PC
* [S1] Basic keyboard keycodes (Ctrl-C, Ctrl-V, Alt-F4, Ctrl-F, Home, End)
* [S1] Toggle button for press-and-hold functionality
* [S2] Wireless connection from mobile devices to PC (related)
* [S2] Limited application shortcuts (Launch web browser, Visual Studio and Task Manager)
* [S3] Custom-defined script executions (User creates batch or python script and corresponding Android button to execute)
* [W2] Windows configuration shortcuts (Volume up/down, Brightness, Lock PC, Restart, Shutdown)
* [W2] Ability to define custom templates on the Android interface and switch between them
* [W3] Creation of customized keycode combinations (I.E. chain together Ctrl-A and Ctrl-C with single press)
* [W4] Common macros available to user.
* [W4] Simple logging of executed commands.
* [C3] Application awareness and contextual execution.
* [C3] Voice-activated controls on Android.
* [C5] Privatized, secure connection between Android and Windows application.

## Non-Functional Standards and Requirements
* Applications should be latency-free. Commands should execute with negligible delay.
* All UI/UX designs should be accessibility-friendly, with easily pressable buttons.
* Android UI should confrom to [Material Design standards](https://material.io/guidelines/material-design/introduction.html). 
	
## Software Standards
	Android API level 23.0
	Google Play Store requirements
	Fragments for command sets
	User friendly intuitive design

## Technologies 
	C# - Windows Application
	Kotlin (tentative) – Android Application
	SQLite – Database storage

## Tools
	Visual studio
	Android studio
	SQLite Admin

## Use Cases
	Cut, copy, paste, 
	Strings; classes, methods, encrypted password (optional) 
	Build, debug
	Step next, into, over
	Breakpoints
	Start IDEs/Applications

