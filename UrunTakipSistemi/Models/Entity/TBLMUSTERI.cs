//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunTakipSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERI()
        {
            this.TBLSATISLAR = new HashSet<TBLSATISLAR>();
        }
    
        public int? ID { get; set; }
        [StringLength(20,MinimumLength = 3,ErrorMessage ="L�tfen ad uzunlu�unu do�ru giriniz.")]
        [Required(ErrorMessage = "Bu alan�n� bo� b�rakam�zs�n�z..")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="L�tfen yanl�zca b�y�k-k���k harf giriniz.")]
        public string AD { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "L�tfen ad uzunlu�unu do�ru giriniz.")]
        [Required(ErrorMessage = "Bu alan�n� bo� b�rakam�zs�n�z..")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "L�tfen yanl�zca b�y�k-k���k harf giriniz.")]
        public string SOYAD { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "L�tfen ad uzunlu�unu do�ru giriniz.")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "L�tfen yanl�zca b�y�k-k���k harf giriniz.")]
        public string SEHIR { get; set; }

        [Range(0,999999999,ErrorMessage ="Pozitif bir de�er giriniz.")]
        public Nullable<decimal> BAKIYE { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLAR { get; set; }
    }
}
