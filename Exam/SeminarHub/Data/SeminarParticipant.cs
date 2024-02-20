﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data
{
    public class SeminarParticipant
    {
        [Required]
        public int SeminarId { get; set; }

        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;

        [Required]
        public string ParticipantId { get; set; } = string.Empty;

        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser User { get; set; } = null!;

    }
}
