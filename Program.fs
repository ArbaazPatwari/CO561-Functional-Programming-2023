open System

// Task 1
type Account = {accountNumber : string; mutable balance: float}
                member this.Print = 
                    Console.Write($"Account: {this.accountNumber}")
                    Console.Write(" | ")
                    Console.Write($"Balance: {this.balance}")

let starter = {accountNumber = "A1X"; balance = 100}

let Withdraw taken = 
    if starter.balance < taken then
        Console.Write("You cannot perform this transaction (balance too low)")
    else 
        starter.balance <- starter.balance - taken

//let lowerBalance = Withdraw 10

let Deposit into =
    starter.balance <- starter.balance + into

//let higherBalance = Deposit 15

starter.Print


// Task 2

Console.Write("\n")

let CheckAccount account =
    match account with
    |_ when account.balance > 100 -> Console.Write("balance is high")
    |_ when account.balance <= 100 && account.balance >= 10 -> Console.Write("balance is ok")
    |_ when account.balance <= 10 && account.balance >= 0 -> Console.Write("balance is low")
    |_ -> Console.Write("... (No account identified)")


let firstAccount = {accountNumber = "0001"; balance = 0.0}
let secondAccount = {accountNumber = "0002"; balance = 51.0}
let thirdAccount = {accountNumber = "0003"; balance = 5.0}
let fourthAccount = {accountNumber = "0004"; balance = 32.0}
let fifthAccount = {accountNumber = "0005"; balance = 105.0}
let sixthAccount = {accountNumber = "0006"; balance = 89.0}

Console.Write("The first account's ") 
CheckAccount firstAccount
Console.Write("\n The second account's")
CheckAccount secondAccount
Console.Write("\n The third account's")
CheckAccount thirdAccount
Console.Write("\n The fourth account's")
CheckAccount fourthAccount
Console.Write("\n The fifth account's")
CheckAccount fifthAccount
Console.Write("\n The sixth account's")
CheckAccount sixthAccount


// Task 3

