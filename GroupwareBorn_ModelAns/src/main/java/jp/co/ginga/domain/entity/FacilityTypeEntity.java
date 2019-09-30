package jp.co.ginga.domain.entity;

import java.sql.Date;

/**
 * 施設種別テーブルEntity
 * @author yoshi
 *
 */
public class FacilityTypeEntity {

	/**
	 * 施設種別ID
	 */
	private int id;

	/**
	 * 施設種別名
	 */
	private String name;

	/**
	 * 登録日時
	 */
	private Date insertDate;

	/**
	 * 更新日時
	 */
	private Date updateDate;

	/**
	 * 最終更新者
	 */
	private String userId;

	/**
	 * @return id
	 */
	public int getId() {
		return id;
	}

	/**
	 * @param id セットする id
	 */
	public void setId(int id) {
		this.id = id;
	}

	/**
	 * @return name
	 */
	public String getName() {
		return name;
	}

	/**
	 * @param name セットする name
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @return insertDate
	 */
	public Date getInsertDate() {
		return insertDate;
	}

	/**
	 * @param insertDate セットする insertDate
	 */
	public void setInsertDate(Date insertDate) {
		this.insertDate = insertDate;
	}

	/**
	 * @return updateDate
	 */
	public Date getUpdateDate() {
		return updateDate;
	}

	/**
	 * @param updateDate セットする updateDate
	 */
	public void setUpdateDate(Date updateDate) {
		this.updateDate = updateDate;
	}

	/**
	 * @return userId
	 */
	public String getUserId() {
		return userId;
	}

	/**
	 * @param userId セットする userId
	 */
	public void setUserId(String userId) {
		this.userId = userId;
	}
}
