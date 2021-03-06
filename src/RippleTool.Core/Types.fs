﻿module RippleTool.Types

open System

//-------------------------------------------------------------------------------------------------

type IssuedCurrency = { Code : string; Issuer : string }
type NativeCurrency = Xrp

type Currency =
    | IssuedCurrency of IssuedCurrency
    | NativeCurrency of NativeCurrency

type Amount = { Value : decimal; Currency : Currency }

type Ledger =
    | Validated
    | Closed
    | Current

type Role =
    | User
    | Gateway

//-------------------------------------------------------------------------------------------------

[<Flags>]
type PaymentFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u
    | NoRippleDirect      = 0x00010000u
    | PartialPayment      = 0x00020000u
    | LimitQuality        = 0x00040000u

type Payment =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : PaymentFlags
      SourceTag           : uint32 option
      DestinationTag      : uint32 option
      Destination         : string
      Amount              : Amount }

[<Flags>]
type AccountSetFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u

type AccountSetFlag =
    | RequireDest         = 1u
    | RequireAuth         = 2u
    | DisallowXrp         = 3u
    | DisableMaster       = 4u
    | AccountTxnId        = 5u
    | NoFreeze            = 6u
    | GlobalFreeze        = 7u
    | DefaultRipple       = 8u

type AccountSet =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : AccountSetFlags
      SetFlag             : AccountSetFlag option
      ClearFlag           : AccountSetFlag option
      TransferRate        : decimal option }

[<Flags>]
type SetRegularKeyFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u

type SetRegularKey =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : SetRegularKeyFlags
      RegularKey          : string option }

[<Flags>]
type OfferCreateFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u
    | Passive             = 0x00010000u
    | ImmediateOrCancel   = 0x00020000u
    | FillOrKill          = 0x00040000u
    | Sell                = 0x00080000u

type OfferCreate =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : OfferCreateFlags
      OfferSequence       : uint32 option
      Expiration          : DateTimeOffset option
      TakerGets           : Amount
      TakerPays           : Amount }

[<Flags>]
type OfferCancelFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u

type OfferCancel =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : OfferCancelFlags
      OfferSequence       : uint32 }

[<Flags>]
type TrustSetFlags =
    | None                = 0x00000000u
    | FullyCanonicalSig   = 0x80000000u
    | SetAuth             = 0x00010000u
    | SetNoRipple         = 0x00020000u
    | ClearNoRipple       = 0x00040000u
    | SetFreeze           = 0x00100000u
    | ClearFreeze         = 0x00200000u

type TrustSet =
    { Account             : string
      Fee                 : Amount
      Sequence            : uint32
      LastLedgerSequence  : uint32 option
      Flags               : TrustSetFlags
      LimitAmount         : Amount
      QualityIn           : decimal option
      QualityOut          : decimal option }

//-------------------------------------------------------------------------------------------------

type Ping =
    { Id                  : string option }

type Random =
    { Id                  : string option }

type Fee =
    { Id                  : string option }

type ServerInfo =
    { Id                  : string option }

type ServerState =
    { Id                  : string option }

type AccountCurrencies =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type AccountInfo =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type AccountLines =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type AccountObjects =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type AccountOffers =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type AccountTransactions =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option
      Binary              : bool option }

type GatewayBalances =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option }

type NoRippleCheck =
    { Id                  : string option
      Account             : string
      Ledger              : Ledger option
      Role                : Role }

type BookOffers =
    { Id                  : string option
      Ledger              : Ledger option
      Taker               : string option
      Limit               : uint32 option
      TakerGets           : Currency
      TakerPays           : Currency }

type RipplePathFind =
    { Id                  : string option
      Ledger              : Ledger option
      SourceAccount       : string
      DestinationAccount  : string
      DestinationAmount   : Amount }

type Submit =
    { Id                  : string option
      TransactionBlob     : string }

type TransactionInfo =
    { Id                  : string option
      TransactionHash     : string
      Binary              : bool option }

//-------------------------------------------------------------------------------------------------

type Transaction =
    | Payment             of Payment
    | AccountSet          of AccountSet
    | SetRegularKey       of SetRegularKey
    | OfferCreate         of OfferCreate
    | OfferCancel         of OfferCancel
    | TrustSet            of TrustSet

type Command =
    | Ping                of Ping
    | Random              of Random
    | Fee                 of Fee
    | ServerInfo          of ServerInfo
    | ServerState         of ServerState
    | AccountCurrencies   of AccountCurrencies
    | AccountInfo         of AccountInfo
    | AccountLines        of AccountLines
    | AccountObjects      of AccountObjects
    | AccountOffers       of AccountOffers
    | AccountTransactions of AccountTransactions
    | GatewayBalances     of GatewayBalances
    | NoRippleCheck       of NoRippleCheck
    | BookOffers          of BookOffers
    | RipplePathFind      of RipplePathFind
    | Submit              of Submit
    | TransactionInfo     of TransactionInfo
