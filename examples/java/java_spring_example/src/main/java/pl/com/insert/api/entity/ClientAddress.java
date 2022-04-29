package pl.com.insert.api.entity;

import java.util.Objects;

public class ClientAddress {

    private String city;
    private String country;
    private String line1;
    private String name;
    private String zipCode;

    public String getCity() {
            return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getLine1() {
        return line1;
    }

    public void setLine1(String line1) {
        this.line1 = line1;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getZipCode() {
        return zipCode;
    }

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ClientAddress that = (ClientAddress) o;
        return Objects.equals(city, that.city) && Objects.equals(country, that.country) && Objects.equals(line1, that.line1) && Objects.equals(name, that.name) && Objects.equals(zipCode, that.zipCode);
    }

    @Override
    public int hashCode() {
        return Objects.hash(city, country, line1, name, zipCode);
    }

    @Override
    public String toString() {
        return line1 + ", " + zipCode + " " + city + ", " + name + ", " + city;
    }
}
