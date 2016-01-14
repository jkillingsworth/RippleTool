﻿module TransactionTypes

open System

//-------------------------------------------------------------------------------------------------

type NativeAmount = uint32

type IssuedAmount = { Value : float; Currency : string; Issuer : string }

type Amount =
    | NativeAmount of NativeAmount
    | IssuedAmount of IssuedAmount

//-------------------------------------------------------------------------------------------------

type Payment = unit
type AccountSet = unit
type SetRegularKey = unit
type OfferCreate = unit
type OfferCancel = unit

[<Flags>]
type TrustSetFlags =
    | FullyCanonicalSig = 0x80000000u
    | SetNoRipple       = 0x00020000u
    | ClearNoRipple     = 0x00040000u

type TrustSet =
    { Account : string
      Fee : Amount
      Flags : uint32
      Sequence : uint32
      LimitAmount : Amount }

//-------------------------------------------------------------------------------------------------

type Transaction =
    | Payment of Payment
    | AccountSet of AccountSet
    | SetRegularKey of SetRegularKey
    | OfferCreate of OfferCreate
    | OfferCancel of OfferCancel
    | TrustSet of TrustSet
