﻿using IngaDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngaDev.Infra.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserName)
                .HasColumnType("varchar(250)").
                IsRequired();
            builder.Property(p => p.Password)
                .HasColumnType("varchar(512)")
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .HasColumnType("DATETIME");
            builder.Property(p => p.UpdatedAt)
                .HasColumnType("DATETIME");
            builder.Property(p => p.DeletedAt)
                .HasColumnType("DATETIME");
            builder.ToTable("Users");

            builder.HasData(new User
            {
                Id = Guid.NewGuid(),
                UserName = "Adminitrador",
                Password = "password",
                CreatedAt = DateTime.Now,
                Active = true

            });
        }
    }
}
