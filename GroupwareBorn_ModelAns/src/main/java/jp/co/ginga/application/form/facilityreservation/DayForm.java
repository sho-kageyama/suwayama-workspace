package jp.co.ginga.application.form.facilityreservation;

import java.util.List;

public class DayForm {

	private int day;
	private boolean holiday;
	private List<ReservationDetailForm> reservationList;





	public int getDay() {
		return day;
	}

	public void setDay(int day) {
		this.day = day;
	}

	public List<ReservationDetailForm> getReservationList() {
		return reservationList;
	}

	public void setReservationList(List<ReservationDetailForm> reservationList) {
		this.reservationList = reservationList;
	}

	public boolean isHoliday() {
		return holiday;
	}

	public void setHoliday(boolean holiday) {
		this.holiday = holiday;
	}
}
