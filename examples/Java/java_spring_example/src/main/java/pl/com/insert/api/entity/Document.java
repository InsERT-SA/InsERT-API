package pl.com.insert.api.entity;

import java.sql.Date;
import java.text.SimpleDateFormat;

public class Document {

    private String documentNumber;
    private String kind;
    private double totalGrossPln;
    private double totalNetPln;
    private Date dueDate;
    private String paymentState;
    private String client;

    public String getDocumentNumber() {
        return documentNumber;
    }

    public void setDocumentNumber(String documentNumber) {
        this.documentNumber = documentNumber;
    }

    public String getKind() {
        return DocumentKind.valueOf(this.kind).getDescription();
    }

    public void setKind(String kind) {
        this.kind = kind;
    }

    public String getTotalGrossPln() {
        return String.format("%.2f", this.totalGrossPln);
    }

    public void setTotalGrossPln(double totalGrossPln) {
        this.totalGrossPln = totalGrossPln;
    }

    public String getTotalNetPln() {
        return String.format("%.2f", this.totalNetPln);
    }

    public void setTotalNetPln(double totalNetPln) {
        this.totalNetPln = totalNetPln;
    }

    public String getDueDate() {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        return sdf.format(this.dueDate);
    }

    public void setDueDate(Date dueDate) {
        this.dueDate = dueDate;
    }

    public String getPaymentState() {
        if (this.paymentState.equals("Unpaid")) {
            return "Nieopłacone";
        } else {
            return "Opłacone";
        }
    }

    public void setPaymentState(String paymentState) {
        this.paymentState = paymentState;
    }

    public String getClient() {
        return client;
    }

    public void setClient(String client) {
        this.client = client;
    }
}
