using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SP.DAL;

namespace SP.DAL.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SP.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DateOfComment");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAnonymous");

                    b.Property<string>("Name");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SP.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SP.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DateEdited");

                    b.Property<bool>("Inactive");

                    b.Property<string>("PhotoPath");

                    b.Property<DateTime>("PostedDate");

                    b.Property<string>("Preview");

                    b.Property<string>("Title");

                    b.Property<string>("UrlTitle");

                    b.Property<int>("Views");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SP.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TimesUsed");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SP.Entities.Comment", b =>
                {
                    b.HasOne("SP.Entities.Post")
                        .WithMany()
                        .ForeignKey("PostId");
                });
        }
    }
}
