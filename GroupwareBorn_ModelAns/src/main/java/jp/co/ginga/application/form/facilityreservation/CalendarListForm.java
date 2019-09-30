package jp.co.ginga.application.form.facilityreservation;

import java.util.List;

import jp.co.ginga.application.form.facility.FacilityForm;

public class CalendarListForm {

	private int year;
	private int month;
	private FacilityForm facility;
	private ReservationDetailForm reservation;
	private List<DayForm> calendar;

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

	public FacilityForm getFacility() {
		return facility;
	}

	public void setFacility(FacilityForm facility) {
		this.facility = facility;
	}

	public List<DayForm> getCalendar() {
		return calendar;
	}

	public void setCalendar(List<DayForm> calendar) {
		this.calendar = calendar;
	}

	public ReservationDetailForm getReservation() {
		return reservation;
	}

	public void setReservation(ReservationDetailForm reservation) {
		this.reservation = reservation;
	}

}
