﻿using MailContainerTest.Models;

namespace MailContainerTest.Services
{
    public interface IMailTransferService
    {
        MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request);
    }
}