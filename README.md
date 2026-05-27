# CQRS & EventSourcing Playground

## Domain - Digital Wallet

## Problem
A digital wallet system must reliably handle money transfers, maintain a complete transaction history, and prevent data inconsistencies caused by concurrent operations. 

Traditional CRUD approaches make auditing, debugging, and recovering historical state difficult.

## Why Cqrs + EventSourcing works well in this case

CQRS separates write and read operations, allowing the system to optimize business logic and query performance independently. 
Event Sourcing stores every state change as an immutable event, providing full auditability, reliable recovery, replay capabilities, and safe concurrency handling.

## Solution

<img width="700" height="375" alt="image" src="https://github.com/user-attachments/assets/87e85b0a-190d-483f-9a49-d16c923402a1" />



