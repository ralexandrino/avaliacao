using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Avaliacao.Domain.Models;

namespace Avaliacao.Infra.Data.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Id).IsRequired();
            builder.Property(q => q.DataLancamento).IsRequired();
            builder.Property(q => q.Nome).IsRequired();
            builder.Property(q => q.TipoProduto).IsRequired();
            builder.Property(q => q.Valor).IsRequired();
        }
    }
}
