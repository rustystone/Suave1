#light


module FsharpApp

open FSharp.Configuration

open Suave
open Suave.Json
open System.Runtime.Serialization
open System.Net
open System

type Settings = AppSettings<"App.config">



[<EntryPoint>]
let main argv = 
    printfn "Hello World" 
    Settings.SuaveIp
    Settings.SuavePort
    Settings.EmailPassword
    
    Console.WriteLine("Settings Suave IP: {0}", Settings.SuaveIp)
    let x1 = Settings.SuavePort |> int
    let int1 = 1
    let s = x1.GetType().Name
    if s = "Int32" then
        Console.WriteLine("Typeof: Settings Suave Port: {0}", (Settings.SuavePort |> int))
    Console.ReadLine() |> ignore
    0



