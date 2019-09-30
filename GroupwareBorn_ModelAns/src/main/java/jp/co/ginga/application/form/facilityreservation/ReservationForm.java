package jp.co.ginga.application.form.facilityreservation;

import jp.co.ginga.application.form.facility.FacilityForm;

public class ReservationForm {

	private int id;

	private int year;

	private int month;

	private int day;

	private String startTime;

	private String endTime;

	private String userId;

	private FacilityForm facility;

	private ReservationDetailForm reservationInfo;

	private String multiError;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getYear() {
		return year;
	}

	public void setYear(int year) {
		this.year = year;
	}

	public int getMonth() {
		return month;
	}

	public void setMonth(int month) {
		this.month = month;
	}

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}


	public int getDay() {
		return day;
	}

	public void setDay(int day) {
		this.day = day;
	}

	public FacilityForm getFacility() {
		return facility;
	}

	public void setFacility(FacilityForm facility) {
		this.facility = facility;
	}

	public ReservationDetailForm getReservationInfo() {
		return reservationInfo;
	}

	public void setReservationInfo(ReservationDetailForm reservationInfo) {
		this.reservationInfo = reservationInfo;
	}

	public String getMultiError() {
		return multiError;
	}

	public void setMultiError(String multiError) {
		this.multiError = multiError;
	}


	public ReservationForm() {

	}

	public ReservationForm(int id, int year, int month, int day, String startTime, String endTime,int facilityId, String userId) {
		super();
		this.id = id;
		this.year = year;
		this.month = month;
		this.day = day;
		this.startTime = startTime;
		this.endTime = endTime;
		FacilityForm facilityForm = new FacilityForm();
		facilityForm.setId(facilityId);
		this.facility = facilityForm;
		this.userId = userId;

	}
}
