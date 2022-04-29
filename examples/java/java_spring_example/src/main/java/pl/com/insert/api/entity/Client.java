package pl.com.insert.api.entity;

public class Client {

    private String name;
    private ClientAddress address;
    private String tin;
    private String tinKind;


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ClientAddress getAddress() {
        return address;
    }

    public void setAddress(ClientAddress address) {
        this.address = address;
    }

    public String getTin() {
        return tin;
    }

    public void setTin(String tin) {
        this.tin = tin;
    }

    public String getTinKind() {
        return tinKind;
    }

    public void setTinKind(String tinKind) {
        this.tinKind = tinKind;
    }
}
