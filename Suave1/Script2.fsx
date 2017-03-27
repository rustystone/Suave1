#r "C:\\PCode2\\Suave1\\Suave1\\packages\\FSharp.Configuration.0.6.4\\lib\\net40\\FSharp.Configuration.dll"
#r "System.Configuration.dll"
open FSharp.Configuration

#r "C:\\PCode2\\Suave1\\Suave1\\packages\\Suave.2.0.5\\lib\\net40\\Suave.dll"
open Suave
#r "System.Runtime.Serialization.dll"
open Suave.Json
open System.Runtime.Serialization
open System.Net
open System

type Settings = AppSettings<"App.config">

Settings.SuaveIp
Settings.SuavePort
Settings.EmailPassword


[<DataContract>]
type Foo =
    {[<field: DataMember(Name = "foo")>]
        foo: string}

[<DataContract>]
type Bar =
    {[<field: DataMember(Name = "bar")>]
        bar: string}

let cfg =
  { defaultConfig with
      bindings =
        [ HttpBinding.create HTTP IPAddress.Loopback 80us
          HttpBinding.createSimple HTTP Settings.SuaveIp (Settings.SuavePort |> int) ]}

startWebServer cfg (mapJson (fun (a:Foo) -> {bar = a.foo}))