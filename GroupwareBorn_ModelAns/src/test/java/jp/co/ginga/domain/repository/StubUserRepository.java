package jp.co.ginga.domain.repository;

import java.util.List;

import jp.co.ginga.domain.entity.UserEntity;
import jp.co.ginga.domain.repository.UserRepository;

public class StubUserRepository implements UserRepository {

	@Override
	public UserEntity findOneByIdAndPassword(String id, String password) {
		// TODO 自動生成されたメソッド・スタブ
		return null;
	}

	@Override
	public UserEntity findOneById(String id) {
		// TODO 自動生成されたメソッド・スタブ
		return null;
	}

	@Override
	public List<UserEntity> findAll() {
		// TODO 自動生成されたメソッド・スタブ
		return null;
	}

	@Override
	public boolean add(UserEntity user) {
		// TODO 自動生成されたメソッド・スタブ
		return false;
	}

	@Override
	public boolean update(UserEntity user) {
		// TODO 自動生成されたメソッド・スタブ
		return false;
	}

	@Override
	public boolean delete(String userName) {
		// TODO 自動生成されたメソッド・スタブ
		return false;
	}


}
