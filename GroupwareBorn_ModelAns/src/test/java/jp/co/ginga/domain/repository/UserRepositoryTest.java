/**
 *
 */
package jp.co.ginga.domain.repository;

import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import jp.co.ginga.domain.entity.UserEntity;

/**
 * @author souken
 *
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class UserRepositoryTest {

	@Autowired
	UserRepository repo;


	@Test
	public void findOneById_001() {

		String id ="aaaaa";

		UserEntity entity = repo.findOneById(id);

		assertEquals(null, entity);

	}

	@Test
	public void findOneById_002() {

		String id ="a0001";

		UserEntity entity = repo.findOneById(id);

		assertEquals(null, entity);

	}
}
