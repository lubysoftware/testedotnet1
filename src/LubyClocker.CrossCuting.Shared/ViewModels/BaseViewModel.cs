using System;

namespace LubyClocker.CrossCuting.Shared.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}