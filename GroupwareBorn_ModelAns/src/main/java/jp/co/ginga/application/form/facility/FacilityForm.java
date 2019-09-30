package jp.co.ginga.application.form.facility;

import java.io.Serializable;

import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import org.hibernate.validator.constraints.Range;

/**
 * 施設情報フォーム
 *
 * @author yoshi
 *
 */
public class FacilityForm implements Serializable {

	/**
	 * 施設ID
	 */
	private int id;

	/**
	 * 施設名
	 */
	@NotEmpty(message = "必須入力です")
	@Size(message = "1文字以上20文字以下で入力してください", max = 20)
	private String name;

	/**
	 * 施設種別ID
	 */
	private int typeId;

	/**
	 * 定員
	 */
	@NotNull(message = "必須入力です")
	@Range(message = "1以上1000未満で入力してください", min = 1, max = 999)
	private int capacity;


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
	 * 施設種別名
	 */
	private String typeName;

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
	 * @return typeId
	 */
	public int getTypeId() {
		return typeId;
	}

	/**
	 * @param typeId セットする typeId
	 */
	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}

	/**
	 * @return capacity
	 */
	public int getCapacity() {
		return capacity;
	}

	/**
	 * @param capacity セットする capacity
	 */
	public void setCapacity(int capacity) {
		this.capacity = capacity;
	}

	/**
	 * @return typeName
	 */
	public String getTypeName() {
		return typeName;
	}

	/**
	 * @param typeName セットする typeName
	 */
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}

	/**
	 * ユーザー名
	 */
	private String userId;

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


	/**
	 * コンストラクタ(デフォルト)
	 */
	public FacilityForm() {

	}

	/**
	 * コンストラクタ(name,typeId,capacity 入力・登録用)
	 * @param name
	 * @param typeId
	 * @param capacity
	 */
	public FacilityForm(int id, String name, int typeId, int capacity, String userId) {
		super();
		this.id = id;
		this.name = name;
		this.typeId = typeId;
		this.capacity = capacity;
		this.userId = userId;

	}

	/**
	 * コンストラクタ(id,name,typeId,capacity,typeName 表示・登録用)
	 * @param id
	 * @param name
	 * @param typeId
	 * @param capacity
	 * @param typeName
	 */
	public FacilityForm(int id,String name, int typeId,String typeName, int capacity) {
		super();
		this.id = id;
		this.name = name;
		this.typeId = typeId;
		this.typeName = typeName;
		this.capacity = capacity;


	}

}
