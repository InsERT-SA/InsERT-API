package pl.com.insert.api.entity;

public enum DocumentKind {

    Receipt("Paragon"),
    Invoice("Faktura"),
    Proforma("Faktura proforma"),
    VatMarginInvoice("Faktura marża");

    private final String description;

    DocumentKind(String description) {
        this.description = description;
    }

    public String getDescription() {
        return description;
    }
}
