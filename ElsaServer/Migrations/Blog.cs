using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Blog
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Type { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public string? SkillRequired { get; set; }

    public Guid? ProjectId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BlogCv> BlogCvs { get; set; } = new List<BlogCv>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual Project? Project { get; set; }

    public virtual User? User { get; set; }
}
