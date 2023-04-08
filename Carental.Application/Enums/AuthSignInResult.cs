﻿using Carental.Application.Attributes;

namespace Carental.Application.Enums
{
    public enum AuthSignInResult
    {
        [EnumMemberMessage("User is Locked out!")]
        LOCKEDOUT,

        [EnumMemberMessage("Signin for this user is not allowed!")]
        NOTALLOWED,

        [EnumMemberMessage("User signin requires two Factor!")]
        REQUIRESTWOFACTOR,

        [EnumMemberMessage("User signin succeeded!")]
        SUCCEEDED,

        [EnumMemberMessage("User signin failed")]
        FAILED
    }
}
