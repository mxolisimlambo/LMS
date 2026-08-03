# LEARNING MANAGEMENT SYSTEM (LMS)

## Frontend Technical Documentation

**Version:** 1.3

**Author:** Mxolisi Goodman

**Technology Stack**

* ASP.NET Core MVC
* ASP.NET Core Web API
* JavaScript (ES6)
* jQuery
* Bootstrap 5
* HTML5
* CSS3
* SQL Server
* Entity Framework Core
* ASP.NET Identity
* JWT Authentication

---

# PART I

# INTRODUCTION

---

# Chapter 1

# Project Overview

## 1.1 Introduction

The Learning Management System (LMS) is an enterprise-level web application designed to provide a complete online learning platform for educational institutions, private training providers, instructors, and students.

The objective of the project is to build a modern, scalable, secure, and maintainable Learning Management System using ASP.NET Core technologies while following software engineering best practices.

Unlike a traditional MVC application where business logic is mixed with views, this project follows a strict modular architecture where every responsibility is separated into dedicated layers.

The frontend communicates exclusively with the Web API.

No page communicates directly with the database.

No page contains business logic.

This architecture makes the application easy to maintain, easy to extend, and suitable for enterprise environments.

---

# 1.2 Vision

The long-term vision of the project is to build one of the most complete Learning Management Systems capable of supporting:

• Universities

• Colleges

• Private Training Institutions

• High Schools

• Corporate Training

• Government Training

• Professional Certifications

• Online Learning

• Hybrid Learning

• Mobile Learning

The system is designed from the beginning to support thousands of users while remaining modular and easy to maintain.

---

# 1.3 Objectives

The project has several objectives.

These objectives guided every architectural decision throughout development.

Primary objectives include:

• Build a reusable frontend architecture.

• Separate presentation from business logic.

• Use API-driven development.

• Use JWT Authentication.

• Use Role-Based Authorization.

• Use Permission-Based Authorization.

• Eliminate duplicated JavaScript.

• Standardize every feature module.

• Simplify onboarding of future developers.

• Reduce maintenance cost.

• Improve scalability.

• Improve security.

• Improve user experience.

---

# 1.4 Development Philosophy

During development several principles were adopted.

These principles became permanent standards for the project.

Every module must:

• Have one responsibility.

• Be reusable.

• Be independently testable.

• Never duplicate code.

• Never bypass the architecture.

• Follow consistent naming conventions.

• Communicate through services.

• Use centralized configuration.

• Be API driven.

• Be secure by default.

---

# 1.5 Technology Stack

Backend

• ASP.NET Core Web API

• ASP.NET Identity

• Entity Framework Core

• SQL Server

• JWT Authentication

Frontend

• ASP.NET Core MVC

• JavaScript ES6

• jQuery

• Bootstrap 5

• HTML5

• CSS3

Development Tools

• Visual Studio 2022

• Git

• GitHub

• SQL Server Management Studio

• Postman

• Swagger

• Chrome Developer Tools

---

# Chapter 2

# Solution Architecture

The LMS solution consists of several independent projects.

Each project has a dedicated responsibility.

```
LMS.API

LMS.Application

LMS.Persistence

LMS.Identity

LMS.Shared

LMS.Web
```

Each project communicates only through well-defined interfaces.

This separation improves maintainability and supports Clean Architecture principles.

---

## LMS.API

Responsibilities

• Exposes REST endpoints

• Authentication

• Authorization

• Validation

• API Responses

• Swagger Documentation

The API never communicates directly with MVC Views.

---

## LMS.Application

Responsibilities

• Business Interfaces

• Application Services

• DTO Contracts

• Validation Rules

• Business Logic

The Application layer contains no UI code.

---

## LMS.Persistence

Responsibilities

• Database Context

• Entity Configurations

• Repositories

• Entity Framework Core

Persistence contains only data access logic.

---

## LMS.Identity

Responsibilities

• ASP.NET Identity

• Login

• Registration

• Password Management

• JWT Generation

• Refresh Tokens

• User Management

• Roles

• Permissions

This project centralizes all identity functionality.

---

## LMS.Shared

Responsibilities

• DTOs

• API Responses

• Shared Enums

• Constants

• JWT Settings

Shared allows every project to use common models without duplication.

---

## LMS.Web

Responsibilities

• User Interface

• MVC Views

• JavaScript

• Bootstrap

• Dynamic Components

• API Communication

LMS.Web never communicates directly with the database.

Everything goes through LMS.API.

---

# Chapter 3

# Frontend Architecture

One of the biggest achievements during this project was replacing a traditional JavaScript structure with a fully modular architecture.

Instead of writing JavaScript directly inside pages, responsibilities were separated into reusable modules.

The application startup is extremely simple.

```
Browser

↓

app.js

↓

Layout.initialize()

↓

PageRegistry.initialize()

↓

CurrentPage.initialize()
```

Only one file starts the application.

```
app.js
```

Every other module waits for initialization.

No page uses:

```
$(document).ready()

$(function())

window.onload
```

This guarantees a consistent startup process across the entire application.

---

# Chapter 4

# LMS.Web Folder Structure

The MVC project is organized into clear areas.

```
Controllers

Views

Shared

Home

Account

Dashboard

Category

Course

Lesson

Instructor

Student

Certificate

Checkout

Reports

Administration

wwwroot

assets

html

shared

home

dashboard

account

course

lesson

category

student

instructor

js

core

features
```

This structure separates:

Presentation

Reusable HTML

Assets

JavaScript

Feature Modules

---

# Chapter 5

# JavaScript Architecture

The JavaScript architecture is the foundation of the frontend.

Every module follows exactly the same pattern.

```
api.js

↓

service.js

↓

events.js

↓

validation.js

↓

ui.js

↓

page.js
```

Every future feature must follow this structure.

Examples include:

Dashboard

Courses

Lessons

Students

Instructors

Certificates

Reports

Administration

No exceptions are allowed.

The architecture guarantees consistency throughout the project.

---

End of Part 1.

Next Part:
**Core Modules (Configuration, Storage Service, Security Service, API Client, Component Loader, Layout Manager, Page Registry, Authentication Flow and Authorization Flow).**
