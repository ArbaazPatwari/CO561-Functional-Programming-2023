open System

// Task 1
type Account = {accountNumber : string; mutable balance: float}

let starter = {accountNumber = "A1X"; balance = 100}

let Withdraw taken = 
    Console.WriteLine("How much money would you like to take out?")
    let taken = float(Console.ReadLine())
    starter.balance <- starter.balance - taken
    Console.WriteLine($"Your balance is now: {starter.balance}")

let lowerBalance = Withdraw 10