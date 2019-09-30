package jp.co.ginga.application.form.facility;

public class FacilityTypeForm {

	private int id;
	
	private String name;
	
	private String userId;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}
	
	public FacilityTypeForm() {
		
	}
	
	public FacilityTypeForm(int id, String name, String userId) {
		super();
		this.id = id;
		this.name = name;
		this.userId = userId;
	}
	
	
}
