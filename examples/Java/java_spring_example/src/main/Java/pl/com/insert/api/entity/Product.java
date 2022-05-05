package pl.com.insert.api.entity;

public class Product {

    private String name;
    private double netPrice;
    private double grossPrice;
    private String currency;
    private String vatRate;
    private String group;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getNetPrice() {
        return String.format("%.2f", this.netPrice);
    }

    public void setNetPrice(double netPrice) {
        this.netPrice = netPrice;
    }

    public String getGrossPrice() {
        return String.format("%.2f", this.grossPrice);
    }

    public void setGrossPrice(double grossPrice) {
        this.grossPrice = grossPrice;
    }

    public String getCurrency() {
        return currency;
    }

    public void setCurrency(String currency) {
        this.currency = currency;
    }

    public String getVatRate() {
        return vatRate;
    }

    public void setVatRate(String vatRate) {
        this.vatRate = vatRate;
    }

    public String getGroup() {
        return group;
    }

    public void setGroup(String group) {
        this.group = group;
    }
}
