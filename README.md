![Logo](Art/Logo150x150.png "Logo")

# Genesis.TestUtil

[![Build status](https://ci.appveyor.com/api/projects/status/oxrmpkc83o4nea4q?svg=true)](https://ci.appveyor.com/project/kentcb/genesis-testutil)

## What?

> All Genesis.* projects are formalizations of small pieces of functionality I find myself copying from project to project. Some are small to the point of triviality, but are time-savers nonetheless. They have a particular focus on performance with respect to mobile development, but are certainly applicable outside this domain.
 
**Genesis.TestUtil** is a simple library containing helpers for test code. It is delivered as a netstandard 1.1 binary.

## Why?

I have found myself copying a bunch of test helper code from project to project. This includes:

* Reactive Extensions test scheduler support (because rx-testing does not support portable profiles)
* `UseCultureAttribute` for xUnit
* `DebugAttribute` for xUnit
* Builder extensions
* Supporting extension methods  

## Where?

The easiest way to get **Genesis.TestUtil** is via [NuGet](http://www.nuget.org/packages/Genesis.TestUtil/):

```PowerShell
Install-Package Genesis.TestUtil
```

## How?

Just install **Genesis.TestUtil** and explore the available helpers.

## Who?

**Genesis.TestUtil** is created and maintained by [Kent Boogaart](http://kent-boogaart.com). Issues and pull requests are welcome.