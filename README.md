# AutoFixture Kata Starter

A starting point for a code kata using AutoFixture.

This exercise builds on two previous exercises:

- [Test Builders in C#](https://github.com/ardalis/BuilderTestSample)
- [FileLogger Mocking Kata](https://github.com/ardalis/kata-catalog/blob/master/katas/File%20Logger.md)

You should be familiar with, and ideally have completed, both of the above exercises before starting this one.

## Introducing AutoFixture

[AutoFixture](https://github.com/AutoFixture) is a tool designed to speed up the "Arrange" or "Setup" portion of your automated tests. It is designed to help developers/testers focus on test behavior instead of the setup steps of the scenario. It supports setting up tests data, creating services to be tested with their dependencies, and mocking of service dependencies (when integrated with Moq).

## Kata Instructions

Having completed the BuilderTestSample exercise and the FileLogger exercise, you now have two working, tested types:

- [OrderService](https://github.com/ardalis/BuilderTestSample/blob/master/src/BuilderTestSample/Services/OrderService.cs)
- `FileLogger`

Your new task is to combine the two by adding logging to the OrderService and testing that it works as expected. You will write these tests using AutoFixture. Add the following log messages:

- If order passes validation, log "Order [[orderId]] validated."
- If order should be expedited, log "Order [[orderId]] expedited."
- After adding order to customer history, if customer qualifies for expedited orders, log "Customer [[First Name]] [[Last Name]] now qualifies for expedited delivery."

