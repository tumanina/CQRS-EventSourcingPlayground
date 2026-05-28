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


1. Create Wallet

<img width="940" height="427" alt="image" src="https://github.com/user-attachments/assets/72537167-419c-44c8-8bb4-62c490391e3e" />


2. Deposit 100 

<img width="940" height="444" alt="image" src="https://github.com/user-attachments/assets/a3490675-d0ab-4cb1-b3ff-b129893c7bb7" />

3. Withdraw 20

<img width="940" height="444" alt="image" src="https://github.com/user-attachments/assets/8aa00d8b-9004-43d1-b085-ba83bb9703fe" />

4.Withdraw 30

<img width="940" height="415" alt="image" src="https://github.com/user-attachments/assets/947a5a6d-4455-42fe-8d40-7088f6f1d68c" />

5. Deposit 200

<img width="940" height="416" alt="image" src="https://github.com/user-attachments/assets/7359786c-5294-43ad-bf08-5e8fa7846234" />

4. Check balance (100 - 20 -30 + 200 = 250)

<img width="950" height="363" alt="image" src="https://github.com/user-attachments/assets/3e3bb47d-f629-45a4-9441-0cd80b8b01dc" />





