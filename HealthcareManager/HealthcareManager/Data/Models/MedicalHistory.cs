namespace HealthcareManager.Data.Models
{
    public class MedicalHistory : Base
    {
        public DateTime? LastPhysicalDate { get; set; }
        public List<Illnesses> Diseases { get; set; } = new List<Illnesses>();
        public List<Medications> CurrentMedications { get; set; } = new List<Medications>();
        public List<Medications> PastMedications { get; set; } = new List<Medications>();
        public List<PastSurgicalHistory> SxHistory { get; set; } = new List<PastSurgicalHistory>();
    }
    public enum Illnesses
    {
        Hypertension,
        Migraines,
        GERD,
        Diabetes,
        Asthma,
        Arthritis,
        Cancer,
        Depression,
        Influenza,
        Pneumonia,
        Tuberculosis,
        COVID19,
        Anemia,
        Bronchitis,
        CeliacDisease,
        Dementia,
        Epilepsy,
        Fibromyalgia,
        Glaucoma,
        Hepatitis,
        KidneyDisease,
        Lupus,
        Malaria,
        Obesity,
        Osteoporosis,
        ParkinsonsDisease,
        Psoriasis,
        Schizophrenia,
        SickleCellDisease,
        Stroke,
        Other
    }
    public enum Medications
    {
        // Prescription Medications
        Metformin,
        Lisinopril,
        Simvastatin,
        Amlodipine,
        Atorvastatin,
        Omeprazole,
        Levothyroxine,
        Metoprolol,
        Losartan,
        Hydrochlorothiazide,

        // Over-the-Counter (OTC) Medications
        Aspirin,
        Ibuprofen,
        Acetaminophen,
        Diphenhydramine,
        Loratadine,
        Cetirizine,
        Famotidine,
        Ranitidine,
        Loperamide,
        BismuthSubsalicylate,
        Pseudoephedrine,
        Phenylephrine,
        Guaifenesin,
        Dextromethorphan,
        Melatonin,
        CalciumCarbonate,
        MagnesiumHydroxide,
        Bisacodyl,
        Senna,
        DocusateSodium,
        Other
    }
    public enum PastSurgicalHistory
    {
        Appendectomy,
        Cholecystectomy,
        HerniaRepair,
        Hysterectomy,
        Mastectomy,
        Prostatectomy,
        Tonsillectomy,
        CoronaryArteryBypass,
        Angioplasty,
        HipReplacement,
        KneeReplacement,
        CSection,
        GastricBypass,
        Colectomy,
        Thyroidectomy,
        CataractSurgery,
        CarpalTunnelRelease,
        GallbladderRemoval,
        SpinalFusion,
        PacemakerInsertion,
        Other
    }
}
